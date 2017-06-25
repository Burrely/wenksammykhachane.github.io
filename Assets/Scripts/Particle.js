
var Particle = function(size, position, speed) {
	this.size = size;
	this.position = position;
	
	if (speed == null) {
		//Mass (size (x * y) will dedicate the speed of the particle).
		//Standard speed for a particle with 1 by 1 (1) mass will have a set pixels speed per second.
		this.speed = 40 / (size.x * size.y);
	} else {
		this.speed = speed;
	}
}

Particle.prototype.FloatUp = function(speedPerSecond) {
	
	if (speedPerSecond == null) {
		this.position.y += -this.speed / 24;
	} else {
		this.position.y += speedPerSecond / 24;
	}
}

Particle.prototype.Draw = function(canvas) {
	
	canvas.fillStyle = "#A3EE3F";
	canvas.fillRect(this.position.x - this.size.x / 2, this.position.y - this.size.y / 2, this.size.x, this.size.y);
	
	//console.log("This pixel is at " + this.position.x + ", " + this.position.y);
	
}

Particle.prototype.CorrectPosition = function(canvasSize) {
	
	if (this.position.y < 0 - this.size.y / 2) {
		this.position.y = canvasSize.y;
	} /*else if (this.position.y > canvas.height - this.size.y/2) {
		this.position.y = 0 - this.size.y / 2;
	}*/
	
}



var Vector2 = function(x, y) {
	this.x = x;
	this.y = y;
}