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

    let tbl = document.getElementById("calendar-body"); // body of the calendar

    // clearing all previous cells
    tbl.innerHTML = "";

    // filling data about month and in the page via DOM.
    monthAndYear.innerHTML = months[month] + " " + year;
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
                        noteText.textContent = note;  // Create a new line for each note
                        cell.appendChild(noteText);
                    });
                }

                row.appendChild(cell);
                date++;
            }
        }

        tbl.appendChild(row); // appending each row into calendar body.
    }
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