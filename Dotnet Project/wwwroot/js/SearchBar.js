function search_element(selector,searchBy) {
    let input = document.getElementById('searchbar').value;
    input = input.toLowerCase();

    var selectElement = document.querySelectorAll(selector);
    selectElement.forEach(function (card) {
        var stadiumName = card.querySelector(searchBy).textContent.toLowerCase();
        if (!stadiumName.includes(input)) {
            card.style.display = "none";
        } else {
            card.style.display = "list-item";
        }
    });
}
    // Add event listener to the input element
document.getElementById('searchbar').addEventListener('keyup', function () {
    search_element('.stadium','.card-title'); // Replace '.stadium-card' with the appropriate selector
});
