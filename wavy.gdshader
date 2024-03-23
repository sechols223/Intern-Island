shader_type canvas_item;



void vertex() {
	VERTEX = VERTEX += vec2(0, UV.y < 0.90 ? sin((MODEL_MATRIX * vec4(VERTEX.x, 0, 0, 1)).x*0.5 + TIME)*5.0 : 0.0);
}

void fragment() {
	// Called for every pixel the material is visible on.
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
