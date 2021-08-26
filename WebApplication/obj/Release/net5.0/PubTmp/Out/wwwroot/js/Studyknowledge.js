const VM = new Vue(
    {
        el: '#app',
        data: {
            T_Name: this.T_Name, //模糊查询，模糊筛选
            tableData: [],  //数据绑定
            currentPage: 1, //初始页
            pagesize: 2,//每页的数据
            total: 0,   //总记录数
            //模态框
            dialogFormVisible: false,
            student_select: {},
            form: {
                StudyknowledgeName: '求Star',
                StudyknowledgeNameType: '求Star',
                StudyknowledgeContent: '求Star',
                CreateDateTime: '2001-04-22',
                StudyknowledgeNameId: '',
                StudyTypeId: ''
            }/*,formLabelWidth:'120px'*/
            , rules: {
                Name: [
                    { required: true, message: '请输入学生姓名', trigger: 'blur' },
                    { min: 2, max: 5, message: '名字不能太长或者太短', trigger: 'blur' }
                ], Sex: [
                    { required: true, message: '请选性别', trigger: 'change' }
                ], CuorseId: [
                    { required: true, message: '请选择科目', trigger: 'change' }
                ]
            }
        }, mounted() {
            this.load();  //列表加载
            this.Getselect(); //下拉数据绑定 学生
        }, methods: {

        }
        
    }
);