jQuery(document).ready(function ($) {
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
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