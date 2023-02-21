$(function () {


    function searchSelect(dataLoop) {

        var selectValue = dataLoop.querySelector(".select-value");
        var selectText = dataLoop.querySelector(".select-text");
        var locationList = dataLoop.querySelector(".location-list");

        var prevValue = "";
        var prevText = "";

        //select açıldıında 
        selectText.addEventListener("click", function () {
            if (dataLoop.classList.contains("visible")) return;

            prevValue = selectValue.value
            prevText = selectText.value;
            selectText.setAttribute("placeholder", prevText);
            selectText.value = "";

            dataLoop.classList.add("visible");
            selectText.removeAttribute("readonly");
        })

        var timer; // arama yapılmak istendiğinde
        selectText.addEventListener("keyup", function () {
            clearTimeout(timer);
            var ms = 500; // milliseconds
            timer = setTimeout(function () {
                get("/home/GetBusLocation?search=" + selectText.value, "get", {}, function (responseText) {
                    locationList.innerHTML = "";
                    var items = JSON.parse(responseText);

                    for (var i = 0; i < items.length; i++) {
                        var e = document.createElement('div');
                        e.setAttribute("data-id", items[i].value);
                        e.innerHTML = items[i].text;
                        e.addEventListener("click", function () {
                            setSelected(this, selectValue, selectText, dataLoop);
                        })
                        locationList.appendChild(e);
                    }
                });
            }, ms);
        })

        // select kapatılmak istendiğinde
        window.addEventListener('click', function (e) {
            if (dataLoop.classList.contains("visible") === false) return;

            if (!dataLoop.contains(e.target)) {
                closeSelect(dataLoop, selectValue, selectText);
                selectText.value = prevText;
                selectValue.value = prevValue;
            }
        });
    }

    function closeSelect(dataLoop, selectText) {
        dataLoop.classList.remove("visible");
        selectText.setAttribute("readonly", "readonly");
    }

    function setSelected(dataLoop, selectValue, selectText, elSelect) {
        var id = dataLoop.dataset.id;
        var text = dataLoop.innerText;

        selectValue.value = id;
        selectText.value = text;
        selectValue.dispatchEvent(new Event("change"));
        selectText.dispatchEvent(new Event("change"));
        closeSelect(elSelect, selectValue, selectText)
    }

    function get(url, method, data, success, error) {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState != XMLHttpRequest.DONE) return;
            if (xmlhttp.status == 200) {
                success(xmlhttp.responseText);
                return;
            }
            if (error)
                error(xmlhttp.responseText);
        };

        xmlhttp.open(method, url, true);
        xmlhttp.send(JSON.stringify(data));
    }


    var selects = document.querySelectorAll(".select-loop");
    for (var i = 0; i < selects.length; i++) {
        var dataLoop = selects[i];
        searchSelect(dataLoop);

        /* default seçilene göre listeyi doldurma*/
        var selectText = dataLoop.querySelector(".select-text");
        selectText.dispatchEvent(new Event("keyup"));
    }


    /* */

    var options = $.extend(true, $.datepicker.regional["tr"], {
        dateFormat: "dd MM yy DD"
    });


    $(".select-calender").each(function (i, value) {
        var $btnToday = $(value).find("#select-today");
        var $btnTomorrow = $(value).find("#select-tomorrow");
        var $btnPicker = $(value).find("#select-date");
        var $btnInput = $(value).find("#hidden-date");

        // bugun butonu tıklanması
        $btnToday.click(function () {
            var today = new Date();
            $btnPicker.datepicker("setDate", today);

            $btnToday.addClass("active");
            $btnTomorrow.removeClass("active");
            $btnPicker.trigger("change");
        });

        // yarın butonu tıklanması
        $btnTomorrow.click(function () {
            var tomorrow = new Date();
            tomorrow.setDate(tomorrow.getDate() + 1);
            $btnPicker.datepicker("setDate", tomorrow);

            $btnTomorrow.addClass("active");
            $btnToday.removeClass("active");
            $btnPicker.trigger("change");
        });

        // tarih seçim yapılması
        $btnPicker.change(function () {
            var date = $btnPicker.datepicker("getDate");
            date.setDate(date.getDate() + 1);
            $btnInput.val(date.toISOString().split('T')[0])
        });
        $btnPicker.datepicker(options);
    });



    $("#location-change").each(function (i, value) {
        var $inpToValue = $(value).find("#select-origin .select-value");
        var $inpToText = $(value).find("#select-origin .select-text");

        var $inpFromValue = $(value).find("#select-destination .select-value");
        var $inpFromText = $(value).find("#select-destination .select-text");

        // lokasyon switch etme
        $(value).find(".location-change").click(function () {
            var toValue = $inpToValue.val();
            var toText = $inpToText.val();

            var fromValue = $inpFromValue.val();
            var fromText = $inpFromText.val();

            $inpFromValue.val(toValue);
            $inpFromText.val(toText);

            $inpToValue.val(fromValue);
            $inpToText.val(fromText);
        });
    });

});