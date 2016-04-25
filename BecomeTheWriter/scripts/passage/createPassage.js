$(function () {
    var classAllPassages = ".allPassages";
    var checkedPassages = ".allPassages input:checked";
    var urlGetAllPassages = "Passage/GetAllPassage";
    var prePassageId = "#prePassage";
    var postPassageId = "#postPassage";

    fillAllPassages();

    $(classAllPassages).change(passagesChecked);

    function passagesChecked() {
        var prePassagesList = $(checkedPassages);
        $(prePassageId).empty();
        $(postPassageId).empty();

        $.each(prePassagesList, function (key, value) {
            var parentSelector = "";
            if ($(value).parents().hasClass("prePassages")) {
                parentSelector = prePassageId;
            }
            if ($(value).parents().hasClass("postPassages")) {
                parentSelector = postPassageId;
            }

            var id = $(value).data("id");;
            var text = $(value).data("text");;
            var inputHidden = $("<input />");
            inputHidden.attr("type", "hidden");
            inputHidden.attr("name", "passage-" + id);
            inputHidden.attr("value", text);

            $(parentSelector).append(inputHidden).append($("<p></p>").text($(value).parent().text()));
        });
    }

    function fillAllPassages() {
        $.ajax({
            url: urlGetAllPassages
        }).done(function (data) {
            for (var i = 0; i < data.length; i++) {
                var passage = data[i];
                var p = document.createElement("p");

                var input = document.createElement("input");
                input.setAttribute("type", "checkbox");
                input.dataset.id = passage.id;
                input.dataset.text = passage.text;
                p.appendChild(input);

                var text = document.createTextNode(passage.text);
                p.appendChild(text);

                $(classAllPassages).append(p);
            }
        });
        $("classAllPassages");
    }
});