// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#edit").click(function (e) {

        e.preventDefault();
        window.history.pushState(null, null, "/Movies/Edit/" + $("#edit_id").val())
        $("#details_movies").css("display", "none")
        $("#edit_movies").css("display", "block")
    });

    $("#details").click(function (e) {

        e.preventDefault();
        window.history.pushState(null, null, "/Movies/Details/" + $("#edit_id").val())
        $("#details_movies").css("display", "block")
        $("#edit_movies").css("display", "none")
        $("#delete_movies").css("display", "none")
    });

    $("#delete").click(function (e) {
        e.preventDefault();
        window.history.pushState(null, null, "/Movies/Delete/" + $("#edit_id").val())
        $("#details_movies").css("display", "none")
        $("#delete_movies").css("display", "block")
    })

    $("#categoryId").change(function (e) {
        e.preventDefault();
        $("#formCategorySubmit").submit();
    })
});