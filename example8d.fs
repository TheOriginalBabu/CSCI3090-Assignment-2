#version 420 core
/*
 *  Simple fragment sharder for laboratory two
 */

in vec3 normal;
in vec4 position;
uniform vec3 eye;
out vec4 FragColor;

struct Light {
	vec4 Lposition;
	vec4 Lcolour;
	vec4 spotDirection;
	float spotCutoff;
	float spotExp;
	int state;
};

layout(std140, binding=1) uniform Lights {
	Light lights[3];
};

layout(std140, binding=2) uniform Material {
	vec4 colour;
	float n;
};

void main() {
	vec3 N = normalize(normal);
	vec3 e = normalize(eye - position.xyz);
	vec4 totalLight = 0.3 * colour;

	for (int i = 0; i < 3; i++) {

		if (lights[i].state == 0) { //skip lights that are toggled off
			continue;
		}

		vec3 L = normalize(vec3(lights[i].Lposition) - position.xyz);
		vec3 H = normalize(L + e);
		float spotCos = dot(L, vec3(normalize(lights[i].spotDirection)));
		float atten = (spotCos < lights[i].spotCutoff)
			? 0.0
			: pow(spotCos, lights[i].spotExp);

		float diffuse = dot(N, L) * atten;
		float specular = 0.0;
		if (diffuse < 0.0) {
			diffuse = 0.0;
		} else {
			specular = pow(max(0.0, dot(N, H)), n) * atten;
		}

		totalLight += diffuse * colour * lights[i].Lcolour //add light diffuse and specular cumulatively
		            + lights[i].Lcolour * specular;
	}

	FragColor = min(totalLight, vec4(1.0)); // clamp combined lighting between 0 and 1
	FragColor.a = colour.a;
}