function filterSlots() {
var allRows = document.querySelectorAll('.history-table tbody tr');

// Loop through each row
allRows.forEach(function (row) {
    // Select the "Occupancy" cell in each row
    var occupancyCell = row.querySelector('td:nth-child(4)');

    // Check if the occupancy is "Occupied"
    if (occupancyCell.textContent.trim().toLowerCase() === 'occupied') {
        // If true, hide the entire row
        row.style.display = 'none';
    } 
    
});
}
function ShowAllSlots() {
    var allRows = document.querySelectorAll('.history-table tbody tr');

    // Loop through each row
    allRows.forEach(function (row) {
        row.style.display = 'table-row';
    });
}
document.getElementById('showAvailable-btn').addEventListener('click', filterSlots);
document.getElementById('showAll-btn').addEventListener('click', ShowAllSlots);