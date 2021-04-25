
#version 330 core
in vec4 oColor;
in vec2 oTexCoord;
out vec4 FragColor;

uniform sampler2D tex;
uniform sampler2D tex2;
uniform float uTime;

void main() {
    FragColor = oColor;
}
