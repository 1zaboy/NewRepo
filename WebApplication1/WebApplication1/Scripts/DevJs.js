function OnSuccess(data) {
    var results = $('#results'); // получаем нужный элемент
    results.empty(); //очищаем элемент
    for (var i = 0; i < data.length; i++) {
        results.append('<li>' + data[i].UserName + '</li>'); // добавляем данные в список
    }
}