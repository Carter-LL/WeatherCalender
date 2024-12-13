// Function to show the modal
var selectedid = ""
function showModal(id) {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
    selectedid = id;
}

function closeModal() { var modal = document.getElementById("myModal"); modal.style.display = "none"; }

// Function to close the modal
document.getElementsByClassName("close")[0].onclick = function() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";


}

// Function to handle scheduling an event
function scheduleEvent() {
    alert("Event scheduled!");

    var val = document.getElementById("eventName");
    console.log(val.value);

    saveData("event-" + selectedid, val.value)

    var modal = document.getElementById("myModal");
    modal.style.display = "none";
    window.location.reload();
}

// Close the modal if the user clicks outside of it
window.onclick = function (event) {
    var modal = document.getElementById("myModal");
    if (event.target === modal) {
        modal.style.display = "none";
    }
}

function saveData(key, value) {
    localStorage.setItem(key, value);
}
function loadData(key) {
    return localStorage.getItem(key);
}
function removeData(key) {
    localStorage.removeItem(key);
}