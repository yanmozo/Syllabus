jQuery(document).ready(function ($) {
    // Change window when an item from the list of syllabus
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
    });
   
    // ------ CLASSROOM POLICIES ------- //
    $("#editpoliciestable").on("click", "td", function () {
        var pID = $(this).parent("tr").find("td:first").text();
        var pItem = $(this).parent("tr").find("td:nth-child(2)").text();

        $('#policy_id_edit').val(pID);
        $('#policy_id_edit_1').val(pID);
        $('#policy_item_edit').val(pItem);
    });

    // ------ BOOKS - BIBLIOGRAPHY ------- //
    $("#BooksBibTable").on("click", ".editbtn", function () {
        var currentRow = $(this).closest("tr");

        var id = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
        var cnum = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
        var title = currentRow.find("td:eq(2)").text(); // get current row 3rd TD
        var author = currentRow.find("td:eq(3)").text();
        var year = currentRow.find("td:eq(4)").text();

        $('#bookID').val(id);
        $('#callNumber').val(cnum);
        $('#bookTitle').val(title);
        $('#bookAuthors').val(author);
        $('#bookYear').val(year);
        $('#bookBtn').val("Update");
    });

    // ------ WEB - BIBLIOGRAPHY ------- //
    $("#OnlineBibTable").on("click", ".editbtn_web", function () {
        var currentRow = $(this).closest("tr");

        var web_id = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
        var wname = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
        var wlink = currentRow.find("td:eq(2)").text(); // get current row 3rd TD

        $('#webID').val(web_id);
        $('#webpageName').val(wname);
        $('#webpageLink').val(wlink);
        $('#webBtn').val("Update");
    });

});


function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";
}

// Edit policy - datatable
$(document).ready(function () {
    $('#editpoliciestable').DataTable();
});
