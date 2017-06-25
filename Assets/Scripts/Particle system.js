console.log("Setting up the canvas.");

var c = document.getElementById("ParticleCanvas");
var canvas = c.getContext("2d");

c.width = window.innerWidth;
c.height = window.innerHeight;

window.addEventListener(
	"resize",
	function(event) {
		c.width = window.innerWidth;
		c.height = window.innerHeight;
	}
);

//

console.log("Starting the particle system..");

var particleDensity = 0.00005; // (x*100)% of the canvas will be covered in particles.
var particleSpawnCount = particleDensity * (c.width * c.height);

console.log("Generating " + particleSpawnCount + " particles");

var smallParticlePercentage = 0.4;
var mediumParticlePercentage = 0.4;
var bigParticlePercentage = 0.2;
console.log("Generating\n" + (smallParticlePercentage * particleSpawnCount) + " small particles. (" + (smallParticlePercentage * 100) + "%)\n" + (mediumParticlePercentage * particleSpawnCount) + " medium particles. (" + (mediumParticlePercentage * 100) + "%)\n" + (bigParticlePercentage * particleSpawnCount) + " big particles. (" + (bigParticlePercentage * 100) + "%)");

var particleList = [];

createParticles(particleSpawnCount * smallParticlePercentage, new Vector2(1, 1));
createParticles(particleSpawnCount * mediumParticlePercentage, new Vector2(1.5, 1.5));
createParticles(particleSpawnCount * bigParticlePercentage, new Vector2(2, 2));

function createParticles(particleSpawnCount, size) {

	var startingListLength = particleList.length;

	console.log(startingListLength);
	
	for (i = startingListLength; i < particleSpawnCount + startingListLength; i++) {
		particleList[i] = new Particle(new Vector2(size.x, size.y), new Vector2(Math.random() * c.width, Math.random() * c.height));
	}
	
}

//

setInterval(Update, 1000/24);

function Update() {
	//console.log("Update");
	canvas.clearRect(0, 0, c.width, c.height);
	
	//Do particle things
	for (i = 0; i < particleList.length; i++) {
		particleList[i].FloatUp(/*Math.random() * 20 * -1*/);
		particleList[i].CorrectPosition(new Vector2(c.width, c.height));
		particleList[i].Draw(canvas);
	}
}