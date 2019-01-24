jQuery(document).ready(function ($) {
    // Change window when an item from the list of syllabus
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
    });
    // Adds a new row to the Book source table
    $(".add-book-row").click(function () {
        var callNumber = $("#callNumber").val();
        var bookTitle = $("#bookTitle").val();
        var bookAuthors = $("#bookAuthors").val();
        var bookYear = $("#bookYear").val();
        var markup = "<tr>" +
            "<td class='BibTD' contenteditable='false'>" + callNumber + "</td>" +
            "<td class='BibTD' contenteditable='false'>" + bookTitle + "</td>" +
            "<td class='BibTD' contenteditable='false'>" + bookAuthors + "</td>" +
            "<td class='BibTD' contenteditable='false'>" + bookYear + "</td>" +
            "<td class='BibTD'>" +
                "<div class='btn-group' role = 'group' aria-label='...'>" + 
                    "<button type='button' class='btn btn-warning editbtn'><span class='glyphicon glyphicon-edit'></span></button>" +
                    "<button type='button' class='btn btn-danger delbtn'><span class='glyphicon glyphicon-trash'></span></button>" +
                "</div >" +
            "</td >" +
            "</tr>";
        $("#BooksBibTable").append(markup);

        $("#callNumber").val("");
        $("#bookTitle").val("");
        $("#bookAuthors").val("");
        $("#bookYear").val("");
    });

    // Adds a new row to the Websource table
    $(".add-online-row").click(function () {
        var webpageName = $("#webpageName").val();
        var webpageLink = $("#webpageLink").val();
        var webmarkup = "<tr>" +
            "<td class='BibTD' contenteditable='false'>" + webpageName + "</td>" +
            "<td class='BibTD' contenteditable='false'>" + webpageLink + "</td>" +
            "<td class='BibTD'>" +
            "<div class='btn-group' role = 'group' aria-label='...'>" +
            "<button type='button' class='btn btn-warning editbtn'><span class='glyphicon glyphicon-edit'></span></button>" +
            "<button type='button' class='btn btn-danger delbtn'><span class='glyphicon glyphicon-trash'></span></button>" +
            "</div >" +
            "</td >" +
            "</tr>";
        $("#OnlineBibTable").append(webmarkup);

        $("#webpageName").val("");
        $("#webpageLink").val("");
    });
    
    //Edit the row in books!! THIS IS WORKING BUT DOESNT WORK WITH MICROSOFT EDGE (OPEN WITH GCHROME)
    $('.editbtn').click(function () {
        var currentTD = $(this).parents('tr').find('td');
        if ($(this).html() === '<span class="glyphicon glyphicon-edit"></span>') {
            currentTD = $(this).parents('tr').find('td');
            $.each(currentTD, function () {
                $(this).prop('contenteditable', true);
            });
        } else {
            $.each(currentTD, function () {
                $(this).prop('contenteditable', false);
            });
        }
        
        $(this).html($(this).html() === '<span class="glyphicon glyphicon-edit"></span>' ? '<span class="glyphicon glyphicon-ok"></span>' : '<span class="glyphicon glyphicon-edit"></span>');
        
    });

    //Edit the row in online!! THIS IS WORKING BUT DOESNT WORK WITH MICROSOFT EDGE (OPEN WITH GCHROME)
    $('.editbtn_web').click(function () {
        var currentTD = $(this).parents('tr').find('td');
        if ($(this).html() === '<span class="glyphicon glyphicon-edit"></span>') {
            currentTD = $(this).parents('tr').find('td');
            $.each(currentTD, function () {
                $(this).prop('contenteditable', true);
            });
        } else {
            $.each(currentTD, function () {
                $(this).prop('contenteditable', false);
            });
        }

        $(this).html($(this).html() === '<span class="glyphicon glyphicon-edit"></span>' ? '<span class="glyphicon glyphicon-ok"></span>' : '<span class="glyphicon glyphicon-edit"></span>');

    });

    //Delete's table row - Book
    $("#BooksBibTable").on('click', '.delbtn', function () {
        $(this).closest('tr').remove();
    });

    //Delete's table row - Online
    $("#OnlineBibTable").on('click', '.delbtn_web', function () {
        $(this).closest('tr').remove();
    });
});

function AddNewField() {
    var field = 
        "<form method='post' action='AddNewPolicyToDB'><div class='input-group' id='newfield'>" +
        "<input type='text' class='form-control' name='PolicyString' id='newPolicyInput' placeholder='Type new policy...'><br>" +
        "<span class='input-group-btn'>" +
        "<button class='btn btn-default' onclick='AddNewPolicy()' type='button'>Add</button>" +
        "</span>" +
        "</div></form><br>";
    document.getElementById("NewInputFields").innerHTML = field;

}

function AddNewPolicy() {
    var newPol = document.getElementById("newPolicyInput").value;
    
    var node = document.createElement("LI");
    var textnode = document.createTextNode(newPol);
    node.appendChild(textnode);
    document.getElementById("PolicyList").appendChild(node);

   this.style.display = "none";
}

function openCity(evt, cityName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}