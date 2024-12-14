let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();
let selectYear = document.getElementById("year");
let selectMonth = document.getElementById("month");

let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

let monthAndYear = document.getElementById("monthAndYear");

// Initialize an empty object for storing multiple notes per date
let dateNotes = {
};
let dateTemps = {};  // To store the temperatures for each date

// Call the initial calendar render
showCalendar(currentMonth, currentYear, dateNotes);

function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    reloadCalendar();  // Reload the calendar with updated notes
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    reloadCalendar();  // Reload the calendar with updated notes
}

function jump() {
    currentYear = parseInt(selectYear.value);
    currentMonth = parseInt(selectMonth.value);
    reloadCalendar();  // Reload the calendar with updated notes
}

function reloadCalendar() {
    showCalendar(currentMonth, currentYear, dateNotes);  // Call showCalendar with the current dateNotes
}
function showCalendar(month, year, dateNotes) {
    let firstDay = (new Date(year, month)).getDay();
    let daysInMonth = 32 - new Date(year, month, 32).getDate();

    let tbl = document.getElementById("calendar-body");

    if (tbl == undefined) { return; }

    // clearing all previous cells
    tbl.innerHTML = "";

    // Update the month and year header
    if (monthAndYear) {
        monthAndYear.innerHTML = months[month] + " " + year;
    }

    document.getElementById("calendarTitle").innerHTML = "Calendar: " + months[month] + " " + year;  // Update the h1 title
    selectYear.value = year;
    selectMonth.value = month;

    // creating all cells
    let date = 1;
    for (let i = 0; i < 6; i++) {
        // creates a table row
        let row = document.createElement("tr");

        // creating individual cells, filling them up with data.
        for (let j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                let cell = document.createElement("td");
                let cellText = document.createTextNode("");
                cell.appendChild(cellText);
                row.appendChild(cell);
            }
            else if (date > daysInMonth) {
                break;
            } else {
                let cell = document.createElement("td");

                // Format the date as MM-DD-YYYY
                let specificDate = `${month + 1}-${date}-${year}`;

                // Get all notes for this specific date
                let notes = getNotesForDate(specificDate, dateNotes);

                // Create a text node for the day number and append it
                let cellText = document.createTextNode(date);
                cell.appendChild(cellText);

                // Check if it's today's date and highlight it
                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                    cell.classList.add("bg-info");
                }

                // Display notes if they exist
                if (notes && notes.length > 0) {
                    notes.forEach(note => {
                        let noteText = document.createElement("div");
                        noteText.textContent = "- " + note;  // Create a new line for each note
                        cell.appendChild(noteText);
                    });
                }

                // Display temperature if it exists
                let temperature = getTempForDate(specificDate, dateTemps);
                if (temperature) {
                    let noteTemp = document.createElement("span");
                    noteTemp.className = "temp-value";
                    noteTemp.textContent = temperature + "°";  // Display the temperature
                    cell.appendChild(noteTemp);
                }

                // Add the click event to open the event form with the specific date
                cell.setAttribute('data-date', specificDate);  // Store the date on the cell
                cell.onclick = function () {
                    showEventForm(specificDate);
                };

                row.appendChild(cell);
                date++;
            }
        }

        tbl.appendChild(row); // appending each row into calendar body.
    }
}



// Function to show the event form overlay with the selected date
function showEventForm(date) {
    // Set the date as the id of the event form
    document.getElementById("eventForm").setAttribute("data-date", date);

    // Show the overlay
    document.getElementById("overlayq").style.display = "flex";
}

// Function to close the overlay form
function closeModal() {
    document.getElementById("overlayq").style.display = "none";
}

function simulateTyping(inputElement, text, interval) {
    let index = 0;

    function typeCharacter() {
        if (index < text.length) {
            let char = text[index];
            inputElement.value += char;

            // Dispatch input event to trigger any listeners
            let event = new Event('input', {
                bubbles: true,
                cancelable: true
            });
            inputElement.dispatchEvent(event);

            index++;
            setTimeout(typeCharacter, interval); // Call the function again after the specified interval
        }
    }

    typeCharacter();
}
var GLOBAL = {};
GLOBAL.DotNetReference = null;
function setDotnetReference(pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
}

// Function to schedule an event (you can modify this to save the event details)
function scheduleEvent() {
    let eventName = document.getElementById("eventName").value;
    let eventTime = document.getElementById("eventTime").value;
    let eventDesc = document.getElementById("eventDesc").value;
    let eventDate = document.getElementById("eventForm").getAttribute("data-date");


    // Example: log the event details
    console.log("Event Scheduled!");
    console.log("Date: " + eventDate);
    console.log("Event Name: " + eventName);
    console.log("Event Time: " + eventTime);
    console.log("Event Description: " + eventDesc);

    // Close the modal after submitting
    closeModal();

    DotNet.invokeMethodAsync("WeatherCalender", "EventSubmitClicked", eventName, eventDate)
        .then(result => {
            
        });
}

function clearForm() {
    document.getElementById("eventName").value = ""
    document.getElementById("eventTime").value = ""
    document.getElementById("eventDesc").value = ""
}

// Function to get the notes for a specific date
function getNotesForDate(date, dateNotes) {
    return dateNotes[date] || [];  // Return the notes array if the date has notes, or an empty array if none
}

// Example function to add a new note to a date and reload the calendar
function addNoteToDate(date, note) {
    console.log("Adding note to calender")
    if (dateNotes[date]) {
        dateNotes[date].push(note);  // If the date already has notes, push the new note
    } else {
        dateNotes[date] = [note];  // If no notes exist for the date, create a new array with the note
    }
    reloadCalendar();  // Reload the calendar to display the updated notes
}

function ClearCalender() {
    dateNotes = [];
    reloadCalendar();
}

const tds = document.querySelectorAll('td');
tds.forEach((td) => {
    td.addEventListener('click', function () {
        // Show the form container when a td is clicked
        var modal = document.getElementById("myModal");
        modal.style.display = "block";
    });
});

function showModal(id) {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
    selectedid = id;
}
function addTempToDate(date, temperature) {
    console.log("Adding temperature to calendar");

    // Store the temperature for the specific date in dateTemps
    dateTemps[date] = temperature;

    reloadCalendar();  // Reload the calendar to reflect the updated temperature
}

function getTempForDate(date, dateTemps) {
    return dateTemps[date];  // Return the temperature for the given date, or undefined if not available
}
