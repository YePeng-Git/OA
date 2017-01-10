var $divInfo = $('#divInfo');

//首页加载一级菜单
function InitMenu() {
    $.post("/Home/LoadMenu", function (json, success, jqXHR) {
        if (!json.success) {
            $.messager.alert("提示", "加载菜单出错：" + json.msg, "error");
            return false;
        }
        $.each(json.rows, function (index, node) {
            $('#divMenu').accordion('add', {
                title: node.MenuName,
                //iconCls: 'icon-menu-' + value.MenuImg.replace(new RegExp('.png'), ''),
                selected: index == 0 ? true : false,
                content: '<div style="padding:0px;"><ul MenuID="' + node.MenuID + '" class="easyui-tree"></ul></div>'
            });
        })
    }, "json");
}

//异步加载子节点，即二级菜单
function InitChildMenu() {
    $('.easyui-tree').tree({
        url: "/Home/LoadChildMenu",
        animate: true,
        loadFilter: function (data, parent) {
            if (data.rows)
                return data.rows;
            else
                return data;
        },
        onBeforeLoad: function (node, param) {
            if (!node) {
                param.ParentID = $(this).attr("MenuID");
            }
            else {
                param.ParentID = node.id;
            }
        },
        onClick: function (node) {
            if (node.attributes) {
                var URL = node.attributes.URL;
                URL = URL.substring(0, 1) == "/" ? URL : "/" + URL;
                openPage(node.text, URL);
            }
        },
        onSelect: function (node) {
            if (!node)
                return;
            $(this).tree("toggle", node.target);

        },
        onLoadSuccess: function (node, data) {
        }
    });
}

//打开新标签
function openPage(title, url) {

    title = title.length > 10 ? title.substring(8) + "..." : title;
    //查看标签是否存在，存在选中，否则新增标签
    var existsTab = $divInfo.tabs('exists', title);
    if (existsTab) {
        $divInfo.tabs('select', title);
        return;
    }

    var tabHeight = $("#divInfo").height() - 29;
    $divInfo.tabs('add', {
        title: title,
        selected: true,
        content: '<iframe src="' + url + '" style="width:100%;height:' + tabHeight + 'px;overflow:hidden;" frameborder="0"></iframe>',
        closable: true,
        tools: [{
            iconCls: 'icon-mini-refresh',
            handler: function () {
                var current_tab = $divInfo.tabs('getTab', title);
                $divInfo.tabs('update', {
                    tab: current_tab,
                    options: {
                        content: '<iframe src="' + url + '" style="width:100%;height:100%;" frameborder="0" scrolling="0"></iframe>',
                    }
                });
            }
        }]
    });
}

//关闭选择标签
function closePage() {
    //获取选中标签
    var tab = $divInfo.tabs('getSelected');
    var index = $divInfo.tabs('getTabIndex', tab);
    $divInfo.tabs('close', index);
}

//tab鼠标右击事件
function tab_contextmenu() {
    $(".tabs").delegate("li:not(:eq(0))", "contextmenu", function (e) {
        //禁止默认鼠标右击事件
        e.preventDefault();
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
    })
}

//tab鼠标右击事件
function contextmenuEvent() {
    /*
        首页标签不能删除，同时也不给于鼠标右键事件
    */

    //刷新
    $("#tabRefresh").bind("click", function () {
        //获取当前选中标签
        var current_tab = $divInfo.tabs('getSelected');
        var url = current_tab.children().attr("src");
        if (url == undefined || url == "") {
            return;
        }
        $divInfo.tabs('update', {
            tab: current_tab,
            options: {
                content: '<iframe src="' + url + '" style="width:100%;height:100%;" frameborder="0" scrolling="0"></iframe>',
            }
        });
    });

    //新窗口打开
    $("#tabOpenFrame").bind("click", function () {
        //获取当前选中标签
        var current_tab = $divInfo.tabs('getSelected');
        var url = current_tab.children().attr("src");
        if (url == undefined || url == "") {
            return;
        }
        window.open(url);
    });

    //关闭所有标签
    $("#tabCloseAll").bind("click", function () {
        //获取标签总数
        var tabCount = $divInfo.tabs("tabs").length;
        for (var i = tabCount; i > 0; i--) {
            $divInfo.tabs("close", i);
        }
    });

    //关闭其他标签
    $("#tabCloseOther").bind("click", function () {
        //获取所有tab
        var tabs = $('.tabs li:not(:eq(0))');
        //获取当前选中标签(根据选中tab的样式来获取tab的title)
        var current_tab_titel = $('.tabs-selected').text();

        $.each(tabs, function (index, item) {
            if (item.innerText != current_tab_titel) {
                $divInfo.tabs('close', item.innerText);
            }
        })
        //设置选定值
        $divInfo.tabs('select', current_tab_titel);
    });

    //关闭右边标签
    $("#tabCloseRight").bind("click", function () {
        //获取所有tab
        var tabs = $('.tabs li:not(:eq(0))');
        //获取当前选中标签(根据选中tab的样式来获取tab的title)
        var current_tab_titel = $('.tabs-selected').text();
        //获取当前选中标签的序号（要除去第一个标签所以减1）
        var current_tab_index = $divInfo.tabs('getTabIndex', $divInfo.tabs('getSelected')) - 1;

        $.each(tabs, function (index, item) {
            if (index > current_tab_index) {
                $divInfo.tabs('close', item.innerText);
            }
        })
        //设置选定值
        $divInfo.tabs('select', current_tab_titel);
    });

    //关闭左边标签
    $("#tabCloseLeft").bind("click", function () {
        //获取所有tab
        var tabs = $('.tabs li:not(:eq(0))');
        //获取当前选中标签(根据选中tab的样式来获取tab的title)
        var current_tab_titel = $('.tabs-selected').text();
        //获取当前选中标签的序号（要除去第一个标签所以减1）
        var current_tab_index = $divInfo.tabs('getTabIndex', $divInfo.tabs('getSelected')) - 1;

        $.each(tabs, function (index, item) {
            if (index < current_tab_index) {
                $divInfo.tabs('close', item.innerText);
            }
        })
        //设置选定值
        $divInfo.tabs('select', current_tab_titel);
    });

    //关闭当前标签
    $("#tabCloseCurrent").bind("click", function () {
        //获取选中标签
        var tab = $divInfo.tabs('getSelected');
        var index = $divInfo.tabs('getTabIndex', tab);
        $divInfo.tabs('close', index);
    });
}

//头部导航移动事件
function topnav_active() {
    $("#topnav li").delegate("a", "mouseover", function () {
        $(this).addClass("active");

        //当前选择a标签子节点span距离left的offset 和a标签距离left的offest
        //span的offset-(span的offset-a标签的offset)/2
        var _left = $(this).offset().left - ($(this).find(".popup").width() - $(this).parent().width()) / 2

        //当前选择a标签的高度 + a标签距离top的高度 + 三角形的高度
        var _top = $(this).parent().height() + $(this).parent().offset().top + parseInt($(this).find(".popup i").css("border-right-width").replace("px", ""));
        $(this).find(".popup").css({
            "left": _left,
            "top": _top
        })

        $(this).find(".popup").show();
    })

    $("#topnav li").delegate("a", "mouseout", function () {
        $(this).removeClass("active");
        $(this).find(".popup").hide();
    });
}

//修改主题
function changeTheme() {
    $("#divTheme").delegate("li", "click", function () {
        var themeName = $(this).find("font").text();

        var $easyuiTheme = $('#easyuiTheme');
        var url = $easyuiTheme.attr('href');
        var href = url.substring(0, url.indexOf('jquery-easyui-1.5')) + 'jquery-easyui-1.5/' + themeName + '/easyui.css';
        $easyuiTheme.attr('href', href);
        var $iframe = $('iframe');
        if ($iframe.length > 0) {
            for (var i = 0; i < $iframe.length; i++) {
                var ifr = $iframe[i];
                $(ifr).contents().find('#easyuiTheme').attr('href', href);
            }
        }
        $.cookie('easyuiThemeName', null, { path: '/' });
        $.cookie('easyuiThemeName', encodeURI(href), {
            expires: 365,
            path: '/'
        });
    })
}