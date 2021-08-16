$(function () {
    $('.select-state').select2({
        width: '100%',
        multiple: false
    });

    var dateToday = new Date();

    $('#date-picker').datepicker({
        dateFormat: "dd/mm/yy",
        minDate: dateToday,
        changeMonth: true,
        changeYear: true
    }).datepicker("setDate", "1");

    if (localStorage.getItem("from") !== null) {
        $('#from').val(localStorage.getItem("from")).trigger('change');
    }

    if (localStorage.getItem("to") !== null) {
        $('#to').val(localStorage.getItem("to")).trigger('change');
    }

    if (localStorage.getItem("date") !== null) {
        $('#date-picker').val(localStorage.getItem("date"));
    }

    $("#getToday").on("click", function () {
        $("#date-picker").datepicker("setDate", "0").trigger('change');
    });

    $("#getTomorrow").on("click", function () {
        $("#date-picker").datepicker("setDate", "1").trigger('change');
    });

    $("#swapLocations").on("click", function () {
        var originId = $('#from').val();
        var destinationId = $('#to').val();
        $('#from').val(destinationId).trigger('change');
        $('#to').val(originId).trigger('change');

    });

    //Users can not select same location as both origin and destination.(Rastgele farklı bir seçenek değil de rank'a göre en üste sıradaki seçiliyor.)
    $("#from").on('change', function () {
        if ($(this).val() === $("#to").val()) {
            var rank = getUniqueFromList($(this).find(':selected').data("rank"));
            console.log("from " + rank);
            $("#to").children('option*[data-rank="' + rank + '"]').prop('selected', true).trigger('change');
        }

        localStorage.setItem("from", $(this).val());
    });

    $("#to").on('change', function () {
        if ($(this).val() === $("#from").val()) {
            var rank = getUniqueFromList($(this).find(':selected').data("rank"));
            console.log("to " + rank);
            $("#from").children('option*[data-rank="' + rank + '"]').prop('selected', true).trigger('change');
        }

        localStorage.setItem("to", $(this).val());
    });

    $("#date-picker").on('change', function () {
        localStorage.setItem("date", $(this).val());
    });

    var locationRankList = [];
    var i = 0;

    $("#from > option").each(function () {
        locationRankList[i++] = $(this).data('rank');
    });

    function getUniqueFromList(selectedVal) {
        var itemsWithoutCurrent = locationRankList.filter(function (x) { return x !== selectedVal; });
        return itemsWithoutCurrent[0];
    }

    $(".journeyItem").slice(0, 10).show();
    $("#loadMore").on('click', function (e) {
        e.preventDefault();
        $(".journeyItem:hidden").slice(0, 10).slideDown();
        if ($(".journeyItem:hidden").length == 0) {
            $("#loadMore").css("display", "none");
        }
    });
});