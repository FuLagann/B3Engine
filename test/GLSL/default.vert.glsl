
#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec4 color;
layout (location = 2) in vec3 texcoord;
layout (location = 3) in vec3 normal;
out vec4 fragColor;

uniform vec2 resolution;

void main() {
	gl_Position = vec4(position, 1.0);
	fragColor = color;
}
