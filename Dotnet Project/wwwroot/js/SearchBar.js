   function search_player() {
        let input = document.getElementById('searchbar').value;
        input = input.toLowerCase();

        var selectElement = document.querySelector('.players');
        var options = selectElement.options;

        for (var i = 0; i < options.length; i++) {
            var optionText = options[i].textContent.toLowerCase();
            if (!optionText.includes(input)) {
                options[i].style.display = "none";
            } else {
                options[i].style.display = "list-item";
            }
        }
    }

    // Add event listener to the input element
    document.getElementById('searchbar').addEventListener('keyup', search_player);