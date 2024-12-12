// Function to show the modal
function showModal() {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
}

// Function to close the modal
document.getElementsByClassName("close")[0].onclick = function() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
}

// Function to handle scheduling an event
function scheduleEvent() {
    alert("Event scheduled!");
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
}

// Close the modal if the user clicks outside of it
window.onclick = function(event) {
    var modal = document.getElementById("myModal");
    if (event.target === modal) {
        modal.style.display = "none";
    }
}
