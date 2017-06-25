
var imageElement = document.getElementById("ImageDisplay");
var descriptionParentElement = document.getElementById("ProductDescriptionDiv");

var pictures = [
    document.getElementById("Picture1").getAttribute("src"), //1
    document.getElementById("Picture2").getAttribute("src"), //2
    document.getElementById("Picture3").getAttribute("src") //3
];

var descriptions = [
    document.getElementById("Description1").innerHTML,
    document.getElementById("Description2").innerHTML,
    document.getElementById("Description3").innerHTML
]


//Sets both the picture and the description elements accordingly to the picked number.
function SetContent(selectedContentNumber) {

    SetPicture(selectedContentNumber);
    SetDescriptionText(selectedContentNumber);

}

//Sets the picture element to the picture that is being selected.
function SetPicture(pictureNumber) {

    pictureNumber--; //Moves down by one to get into array format.

    imageElement.setAttribute("src", pictures[pictureNumber]);

}

//Sets the description innerHTML to the html (text) that is being selected.
function SetDescriptionText(descriptionNumber) {

    descriptionNumber--;

    descriptionParentElement.innerHTML = descriptions[descriptionNumber];

}