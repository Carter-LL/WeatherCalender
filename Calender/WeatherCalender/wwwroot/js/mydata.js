var plannedEventsData = [];
var userdata = [];

var grid_plannedevents = undefined;
var grid_userdata = undefined;

function Load_grid_plannedevents() {
    if (grid_plannedevents == undefined) {
        grid_plannedevents = new gridjs.Grid({
            columns: ["Id", "Desktop", "Date", "Description"],
            data: [

            ]
        }).render(document.getElementById("wrapper_plannedevents"));
    }
}

function Load_grid_userdata() {
    if (grid_userdata == undefined) {
        grid_userdata = new gridjs.Grid({
            columns: ["Desktop", "Latitude Encrypted", "Longitude Encrypted", "Latitude Decrypted (Not Stored)", "Longitude Decrypted (Not Stored)"],
            data: []
        }).render(document.getElementById("wrapper_userdata"));
    }
}

function ClearAllGridData() {
    location.reload();
}

// Function to add data to the grid
function addDataToPlannedEventsGrid(id, desktop, date, description) {
    Load_grid_plannedevents();
    // Create a new row from the provided parameters
    const newRow = [id, desktop, date, description];

    // Use the grid's update method to add the new row to the data
    grid_plannedevents.updateConfig({
        data: grid_plannedevents.config.data.concat([newRow]) // Append the new row
    }).forceRender();
}

// Example usage to add new data
addDataToPlannedEventsGrid(plannedEventsData);




// Function to add data to the grid
function addDataToUserDataGrid(id, latenc, longenc, latdec, longdec) {
    Load_grid_userdata();
    // Create a new row from the provided parameters
    const newRow = [id, latenc, longenc, latdec, longdec];

    // Use the grid's update method to add the new row to the data
    grid_userdata.updateConfig({
        data: grid_userdata.config.data.concat([newRow]) // Append the new row
    }).forceRender();
}

// Example usage to add new data
addDataToUserDataGrid(userdata);

