$(document).ready(function () {

    $("#start_parse").click(function () {
        $("#start_parse").prop("disabled", true);
        $("#parse_loading").show();
        $("#parsed_item").hide();
        var data = $("#url").val();

        $.post("/Parser/Parse", {
            url: data
        })
            .done(function (data) {
                console.dir(data);
                if (data.error == "true") {
                    alert(data.errorMessage);
                } else {
                    $("#parsed_item").show();
                    $("#item_name").html(data.item.name);
                    $("#item_category").html(data.item.category);
                    $("#item_price").html(data.item.price);
                    $("#item_site").html(data.item.site);
                    $("#item_author").html(data.item.author_name);
                    $("#item_link").attr("href", "/items/item?id=" + data.item.id);
                }
            })
            .fail(function (data) {
                alert("Uknown error. Please contact administration.");
            })
            .always(function () {
                load_complete();
            });
    });

    function load_complete() {
        $("#start_parse").prop("disabled", false);
        $("#parse_loading").hide();
    }
});