$(function () {
    Initialization();
    initialDatagrid();
})

function initialDatagrid() {
    $.MyAJAX([], "/ProductionCategory/GetDataList", initSuccessful, err);
}
function initSuccessful(result) {
    if (result != "") {
        $("#dg").datagrid('loadData', result);
    }
    else {
        $.messager.alert('警告', '数据为空或加载失败！', 'warning');
    }
}

function datagridDelete() {
    var selectedRow = $("#dg").datagrid('getSelected');
    if (selectedRow == null) {
        $.messager.alert('警告', '未选择目标行，请选中一行数据！', 'warning');
    }
    else {
        var dataToServer = {
            id: selectedRow["Id"],
            code: selectedRow["Code"],
            name: selectedRow["Name"],
            unit: selectedRow["Unit"],
            cost: selectedRow["Cost"],
            profit: selectedRow["Profit"],
            createDate: selectedRow["CreateDate"]
        };
        $.MyAJAX(dataToServer, "/ProductionCategory/Delete", dialogDeleteSuccessful, err);

        //var selectedIndex = $("#dg").datagrid('getRowIndex', selectedRow);
        //$("#dg").datagrid('deleteRow', selectedIndex);
    }
}
function dialogDeleteSuccessful(result) {
    if (result != "0") {
        $('#editDialog').dialog('close');
        initialDatagrid();
        $.messager.alert('提示', '删除成功', 'info');
    }
    else {
        $('#editDialog').dialog('close');
        $.messager.alert('警告', '数据删除失败！', 'warning');
    }
}

function dialogSave() {
    var dataToServer = {
        code: $("#code").textbox('getText'),
        name: $("#name").textbox('getText'),
        unit: $("#unit").textbox('getText'),
        cost: $("#cost").numberbox('getValue'),
        profit: $("#profit").numberbox('getValue')
    }

    $.MyAJAX(dataToServer, "/ProductionCategory/Add", dialogSaveSuccessful, err);
}
function dialogSaveSuccessful(result) {
    if (result == "1") {
        $('#dd').dialog('close');
        $.messager.alert('提示', '保存成功', 'info');
        initialDatagrid();
    }
    else {
        $('#dd').dialog('close');
        $.messager.alert('警告', '数据添加失败！', 'warning');
    }
}

function Initialization() {

    $('#dg').datagrid({
        data: [],
        title: '',
        toolbar: [{
            iconCls: 'icon-reload',
            text: '刷新',
            handler: function () { initialDatagrid(); }
        }, '-', {
            iconCls: 'icon-add',
            text: '增加',
            handler: function () { $('#dd').dialog('open') }
        }, '-', {
            iconCls: 'icon-remove',
            text: '删除',
            handler: function () { datagridDelete() }
        }, '-', {
            iconCls: 'icon-edit',
            text: '编辑',
            handler: function () { alert('help') }
        }],
        singleSelect: true, rownumbers: true, striped: true,
        onDblClickRow: function (index, row) {
            alert();
        },
        columns: [[
            {
                field: 'Code', title: '产品编号', width: '20%', align: 'center'
            },
            {
                field: 'Name', title: '产品名称', width: '20%', align: 'center'
            },
            {
                field: 'Unit', title: '单位', width: '10%', align: 'center'
            },
            {
                field: 'Cost', title: '成本', width: '15%', align: 'center'
            },
            {
                field: 'Profit', title: '利润', width: '15%', align: 'center'
            },
            {
                field: 'CreateDate', title: '创建时间', width: '18%', align: 'center'
            }
        ]]
    });

    $('#dd').dialog({
        title: '添加产品信息', width: 300, height: 220, closed: true,
        toolbar: [{
            text: '保存',
            iconCls: 'icon-save',
            handler: function () { dialogSave() }
        }, {
            text: '帮助',
            iconCls: 'icon-help',
            handler: function () { alert('help') }
        }]
    });
}

function err() {
    $.messager.alert('警告', '程序执行错误！', 'warning');
}