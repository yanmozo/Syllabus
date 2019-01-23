jQuery(document).ready(function ($) {
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
    });
    $(".add-book-row").click(function () {
        var callNumber = $("#callNumber").val();
        var bookTitle = $("#bookTitle").val();
        var bookAuthors = $("#bookAuthors").val();
        var bookYear = $("#bookYear").val();
        var markup = "<tr>" +
            "<td class='BibTD'>" + callNumber + "</td>" +
            "<td class='BibTD'>" + bookTitle + "</td>" +
            "<td class='BibTD'>" + bookAuthors + "</td>" +
            "<td class='BibTD'>" + bookYear + "</td>" +
            "</tr>";
        $("#BooksBibTable").append(markup);
    });
});

function AddNewField() {
    var field = 
        "<div class='input-group' id='newfield'>" +
        "<input type='text' class='form-control' id='newPolicyInput' placeholder='Type new policy...'>" +
        "<span class='input-group-btn'>" +
        "<button class='btn btn-default' onclick='AddNewPolicy()' type='button'>Add</button>" +
        "</span>" +
        "</div><br>";
    document.getElementById("NewInputFields").innerHTML += field;

}

function AddNewPolicy() {
    var newPol = document.getElementById("newPolicyInput").value;
    
    var node = document.createElement("LI");
    var textnode = document.createTextNode(newPol);
    node.appendChild(textnode);
    document.getElementById("PolicyList").appendChild(node);

   this.style.display = "none";
}