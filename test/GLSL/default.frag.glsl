
#version 330 core

precision mediump float;

in vec4 fragColor;
out vec4 outColor;

uniform float time;
uniform vec2 mouse;
uniform vec2 resolution;

float plot(vec2 st, float pt) {
	return (
		smoothstep(pt - 0.02, pt, st.y) -
		smoothstep(pt, pt + 0.02, st.y)
	);
}

void main() {
	// Variables
	vec2 st = gl_FragCoord.xy / resolution;
	float y = smoothstep(0.1, 0.9, (1.0 - (mouse.y / resolution.y)));
	float pt = plot(st, y);
	vec3 color = vec3(y);
	
	color = (1.0 - pt) * color + pt * vec3(0.0, 1.0, 0.0);
	outColor = vec4(color, 1.0);
}
