function showHint(str) {
    if (str.length == 0) {
        document.getElementById("textHint").innerHTML = "";
        return;
    } else {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var suggestions = JSON.parse(this.responseText); // Parse JSON response
                var suggestionsList = suggestions.map(function (product) {
                    return `<div class='suggestion'><a href='/Product/ProductDetails/${product.id}'>${product.name}</a></div>`;
                }).join("");

                document.getElementById("textHint").innerHTML = `<div class='suggestions-container'>${suggestionsList}</div>`;
            }
        };
        xmlhttp.open("GET", "/Product/GetSuggestions?input=" + str, true);
        xmlhttp.send();
    }
}
