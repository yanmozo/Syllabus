jQuery(document).ready(function ($) {
    // Change window when an item from the list of syllabus
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
    });
    // Adds a new row to the table
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
    });
     //Find and remove selected table rows
    $(".DelBookBtn").click(function () {
        $("table tbody").find('input[name="record"]').each(function () {
            if ($(this).is(":checked")) {
                $(this).parents("tr").remove();
            }
        });
    });
    //Edit the row !! THIS IS WORKING BUT DOESNT WORK WITH MICROSOFT EDGE (OPEN WITH GCHROME)
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

    //$('#tableid').on('click', buttonSelector, function () {
    //    $(this).closest('tr').remove();
    //});

    //Adds a new row to the table Learning Plan
    $(".add-learning-plan-row").click(function () {
        var lpMarkup = "<tr class='delLP'>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD' contenteditable='false'><textarea class='form-control'></textarea></td>" +
            "<td class='LPTD'>" +
            "<div class='btn-group' role = 'group' aria-label='...'>" +
            "<button type='button' class='btn btn-warning editLPbtn'><span class='glyphicon glyphicon-edit'></span></button>" +
            "<button type='button' class='btn btn-danger delLPbtn'><span class='glyphicon glyphicon-trash'></span></button>" +
            "</div >" +
            "</td >" +
            "</tr>";
        $("#LearningPlanBody").append(lpMarkup);
    });

});

function AddNewField() {
    var field = 
        "<div class='input-group' id='newfield'>" +
        "<input type='text' class='form-control' id='newPolicyInput' placeholder='Type new policy...'><br>" +
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

function editRow() {
    var $this = $(this);
    var tds = $this.closest('tr').find('td').filter(function () {
        return $(this).find('.EditBookBtn').length === 0;
    });
    if ($this.html() === 'Edit') {
        $this.html('Save');
        tds.prop('contenteditable', true);
    } else {
        $this.html('Edit');
        tds.prop('contenteditable', false);
    }
}