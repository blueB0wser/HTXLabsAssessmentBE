// FULL DISCLAIMER: I used these sources as a guide on how to program boids.
// Primary source: https://people.cs.ksu.edu/~bbp9857/boid.html
// Secondary source: http://www.coderholic.com/boids/
// Secondary source: http://www.coderholic.com/javascript-boids/
// Secondary source: https://eater.net/boids
// Tried to get this working, but ultimately gave up on it: https://vectorjs.org/tutorials/getting-started/
// Also briefly tried using c# code (wpf) but that didn't work out

//import Interactive from "https://vectorjs.org/interactive.js";

document.getElementById('myCanvas').addEventListener("mousemove", MouseMove);
document.getElementById('myCanvas').addEventListener("mousedown", MouseDown);
document.getElementById('myCanvas').addEventListener("mouseup", MouseUp);

const documentWidth = document.getElementById("myCanvas").width;
const documentHeight = document.getElementById("myCanvas").height;
const widthBetweenBoids = 20;

var mouseXPosition = null;
var mouseYPosition = null;

var canvas = document.getElementById("myCanvas");
var canvasWidth = canvas.width;
var canvasHeight = canvas.height;
var ctx = canvas.getContext("2d");

var NumberOfBoids = 10;
var BoidsList = [];
var updateFrequency = 20;
var distanceFromEdge = 5;

function Boid() {
    this.Position = new Vector();

    this.Position.XDimension = returnRandomTimes256();
    this.Position.YDimension = returnRandomTimes256();
}

function Vector() {
    this.XDimension = 0
    this.YDimension = 0

    this.AddVector = function (vector) {
        this.XDimension += vector.XDimension;
        this.YDimension += vector.YDimension;
    }
}

// Mostly for initial positioning 
function returnRandomTimes256() {
    return Math.random() * 256 * 1.2;
}

function AddBoidsToList() {
    for (var i = 0; i < NumberOfBoids; i++) {
        BoidsList.push(new Boid())
    }
}

function MouseDown(e) {
    mouseXPosition = e.clientX - 385;
    mouseYPosition = e.clientY - 50;
}

function MouseUp(e) {
    mouseXPosition = null;
    mouseYPosition = null;
}

function MouseMove(e) {
    if (mouseXPosition == null) return;
    mouseXPosition = e.clientX - 385;
    mouseYPosition = e.clientY - 50;
}

function FindCenterOfBoids() {
    var centerPosition = new Vector();
    if (mouseXPosition != null) {
        centerPosition.XDimension = mouseXPosition;
        centerPosition.YDimension = mouseYPosition;
    }
    else {
        for (var i = 0; i < NumberOfBoids; i++) {
            centerPosition.AddVector(BoidsList[i].Position)
        }
        centerPosition.XDimension /= NumberOfBoids;
        centerPosition.YDimension /= NumberOfBoids;
    }

    return centerPosition;
}


function MoveBoids() {
    var centerOfBoids = FindCenterOfBoids();
    var centerXPosition = centerOfBoids.XDimension;
    var centerYPosition = centerOfBoids.YDimension;

    // Fill in the center point as a blue square
    ctx.fillStyle = "blue";
    ctx.strokeStyle = "black";
    ctx.fillRect(centerXPosition, centerYPosition, 10, 10);
    ctx.strokeRect(centerXPosition, centerYPosition, 10, 10);

    // Reset the color for the rest of the boids
    ctx.fillStyle = "red";
    ctx.strokeStyle = "black";

    for (var boid of BoidsList) {
        // Move Towards center
        var boidXPosition = boid.Position.XDimension;
        var boidYPosition = boid.Position.YDimension;

        if (boidXPosition < centerXPosition) {
            boidXPosition += centerXPosition / NumberOfBoids;
        }
        else if (boidXPosition > centerXPosition) {
            boidXPosition -= centerXPosition / NumberOfBoids;
        }
        if (boidYPosition < centerYPosition) {
            boidYPosition += centerYPosition / NumberOfBoids;
        }
        else if (boidYPosition > centerYPosition) {
            boidYPosition -= centerYPosition / NumberOfBoids;
        }

        // NOTE: This code used to make it move down and right, when it went over, it just looped.
        //       I commented it out, mostly because it doesn't do as much now.

        // // Avoid nearest neighbors
        //for (var secondBoid of BoidsList) {
        //    var secondBoidXPosition = secondBoid.Position.XDimension;
        //    var secondBoidYPosition = secondBoid.Position.YDimension;
        //    var distanceX = Math.abs(secondBoidXPosition - boidXPosition);
        //    var distanceY = Math.abs(secondBoidYPosition - boidYPosition);
        //    // Don't check itself
        //    if (secondBoid == boid) {
        //        continue;
        //    }
        // // Keep in bounds
        //    if (distanceX < widthBetweenBoids) {
        //        boidXPosition += widthBetweenBoids
        //    }

        //    if (distanceY < widthBetweenBoids) {
        //        boidYPosition += widthBetweenBoids
        //    }
        //}

        if (boidXPosition > documentWidth) {
            boidXPosition -= documentWidth;
        }
        if (boidYPosition > documentHeight) {
            boidYPosition -= documentHeight;
        }

        boid.Position.XDimension = boidXPosition;
        boid.Position.YDimension = boidYPosition;
    }
}

//var canvasData = ctx.getImageData(0, 0, canvasWidth, canvasHeight);

// RENDER THE SCREEN / UPDATE FUNCTION
function draw() {
    ctx.clearRect(0, 0, documentWidth, documentHeight);
    ctx.fillStyle = "red";
    ctx.strokeStyle = "black";

    MoveBoids();
    for (var i = 0; i < NumberOfBoids; i++) {
        ctx.fillRect(BoidsList[i].Position.XDimension, BoidsList[i].Position.YDimension, 10, 10);
        ctx.strokeRect(BoidsList[i].Position.XDimension, BoidsList[i].Position.YDimension, 10, 10);
    }

    setTimeout(draw, 200);
}

AddBoidsToList();
draw();
