﻿
// Start of Revision History 
$(document).ready(function () {
    var counter = 0;

    $("#add_revision").on("click", function () {
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td><input type="text" class="form-control" name="version_no"/></td>';
        cols += '<td><input type="text" class="form-control" name="description"/></td>';
        cols += '<td><input type="text" class="form-control" name="revised_by"/></td>';
        cols += '<td><input type="date" class="form-control" name="revision_date"/></td>';
        cols += '<td><input type="text" class="form-control" name="approved_by"/></td>';
        cols += '<td><input type="date" class="form-control" name="approved_date"/></td>';

        cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger "  value="Delete"></td>';
        newRow.append(cols);
        $("table.revision-list").append(newRow);
        counter++;
    });



    $("table.revision-list").on("click", ".ibtnDel", function (event) {
        $(this).closest("tr").remove();
        counter -= 1
    });


});

function calculateRow(row) {
    var price = +row.find('input[name^="price"]').val();

}

function calculateGrandTotal() {
    var grandTotal = 0;
    $("table.order-list").find('input[name^="price"]').each(function () {
        grandTotal += +$(this).val();
    });
    $("#grandtotal").text(grandTotal.toFixed(2));
}
// End of Revision History 

// Start of Course Outcomes 
$(document).ready(function () {
    var counter = 0;

    $("#add_course_outcomes").on("click", function () {
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td><input type="text" class="form-control" name="code"/></td>';
        cols += '<td><input type="text" class="form-control" name="course_outcomes"/></td>';
        cols += '<td><input type="checkbox" name="cv_S' + counter + '"/></td>';
        cols += '<td><input type="checkbox" name="cv_V' + counter + '"/></td>';
        cols += '<td><input type="checkbox" name="cv_D' + counter + '"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_1"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_2"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_3"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_4"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_5"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_6"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_7"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_8"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_9"/></td>';
        cols += '<td><input type="text" class="form-control" name="program_outcomes_10"/></td>';
        cols += '<td><input type="text" class="form-control" name="domain_learning_level"/></td>';

        cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger "  value="Delete"></td>';
        newRow.append(cols);
        $("table.course-list").append(newRow);
        counter++;
    });

    $("table.course-list").on("click", ".ibtnDel", function (event) {
        $(this).closest("tr").remove();
        counter -= 1
    });
});
// End of Course Outcomes


// Start of Course Deliverables Outputs and Requirements 
$(document).ready(function () {
    var counter = 0;

    $("#add_deliverables_requirements").on("click", function () {
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td> <br /><input type="text" class="form-control" name="requirement"/></td>';
        cols += '<td><textarea cols="30" rows="3" class="form-control" style="border:none;" name="requirement_description"/></td>';
        cols += '<td>1 - <input type="checkbox" name="CO_1" value="1">' +
            '<br>2 - <input type="checkbox" name="CO_2" value="2">' +
            '<br>3 - <input type="checkbox" name="CO_3" value="3"></td >';

        cols += '<td><br /><select><option value="rubric_based">Rubric-Based</option>' +
            '<option value="non_rubric_based">Non-Rubric-Based</option></select></td>';

        cols += '<td><br /><select><option value="formative">Formative</option>' +
            '<option value="submmative">Summative</option></select></td>';

        cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger "  value="Delete"></td>';
        newRow.append(cols);
        $("table.deliverables-requirements").append(newRow);
        counter++;
    });

    $("table.deliverables-requirements").on("click", ".ibtnDel", function (event) {
        $(this).closest("tr").remove();
        counter -= 1
    });
});

    /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
    var dropdown = document.getElementsByClassName("dropdown-btn");
        var i;

        for (i = 0; i < dropdown.length; i++) {
        dropdown[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var dropdownContent = this.nextElementSibling;
            if (dropdownContent.style.display === "block") {
                dropdownContent.style.display = "none";
            } else {
                dropdownContent.style.display = "block";
            }
        });
    }
// End of Course Deliverables Outputs and Requirements 

// getting data from the grading_system table 
var HTMLtbl =
    {
        getData: function (table) {
            var data = [];
            table.find('tr').not(':first').each(function (rowIndex, r) {
                var cols = [];
                $(this).find('td').each(function (colIndex, c) {

                    if ($(this).children(':text,:hidden').length > 0)
                        cols.push($(this).children('input').val().trim());

                    // if dropdown text is needed then uncomment it and remove SELECT from above IF condition//
                    // else if ($(this).children('select').length > 0)
                    // cols.push($(this).find('option:selected').text());
                    else
                        cols.push($(this).text().trim());
                });
                data.push(cols);
            });
            return data;
        }
    }


/*$(document).on('click', '#grading_btn_id', function () {
    var oTable = document.getElementById('grading_table');
    var rowLength = oTable.rows.length;
    for (i = 0; i < rowLength; i++) {
        var oCells = oTable.rows.item(i).cells;
        var cellLength = oCells.length;
        for (var j = 0; j < cellLength; j++) {
            var cellVal = oCells.item(j).innerHTML;
            alert("Current data: " + cellVal);
        }
    }
});*/


$(document).on('click', '#grading_btn_id', function () {
    var data = HTMLtbl.getData($('#grading_table'));  // passing that table's ID //
  
    //Mmakuha na ang data diri
    var parameters = {};
    parameters.array = data;

    var request = $.ajax({
        async: true,
        cache: false,
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Teacher/SaveData",
        data: JSON.stringify(parameters)
    });

    alert(data);
    request.done(function (msg) {
        alert("Row saved " + msg.d);
    });

    request.fail(function (jqXHR, textStatus) {
        alert("Request failed: " + textStatus);
    });

});

