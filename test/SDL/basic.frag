
#version 330 core
in vec4 oColor;
in vec2 oTexCoord;
out vec4 FragColor;

uniform sampler2D tex;
uniform sampler2D tex2;
uniform float uTime;

void main() {
	// Variables
	float occ = abs(sin(0.25 * uTime));
	vec4 first = occ * texture(tex, oTexCoord);
	vec4 second = (1.0 - occ) * texture(tex2, oTexCoord);
	
    FragColor = oColor * (first + second);
}
