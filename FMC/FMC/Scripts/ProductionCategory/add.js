function addProduction() {
    var dataToServer = {
        code: $("#code").textbox('getText'),
        name: $("#name").textbox('getText'),
        unit: $("#unit").textbox('getText'),
        cost: $("#cost").numberbox('getValue'),
        profit: $("#profit").numberbox('getValue')
    }

    $.MyAJAX(dataToServer, "/ProductionCategory/Add", successful);
}

function successful(data){
    $.messager.show({
        title: '提示',
        msg: '添加成功！',
        style: {
            right: '',
            bottom: ''
        }
    });
}