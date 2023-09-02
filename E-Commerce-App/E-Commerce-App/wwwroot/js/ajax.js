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
                    return `<a href='/Product/ProductDetails/${product.id}'>` + product.name + " </a>";
                }).join("");

                document.getElementById("textHint").innerHTML ="<div style='background-coloe:red; height:100px;'>" +suggestionsList + "</div>";
            }
        };
        xmlhttp.open("GET", "/Product/GetSuggestions?input=" + str, true);
        xmlhttp.send();
    }
}