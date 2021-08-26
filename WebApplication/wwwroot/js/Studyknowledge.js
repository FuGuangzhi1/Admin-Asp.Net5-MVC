const VM = new Vue(
    {
        el: '#app',
        data: {
            SearchStudyknowledgeName: this.SearchStudyknowledgeName, //模糊查询，模糊筛选
            tableData: [],  //数据绑定
            currentPage: 1, //初始页
            pagesize: 2,//每页的数据
            total: 0,   //总记录数
            //模态框
            dialogFormVisible: false,
            StudyType: [],
            form: {
                StudyknowledgeName: '求Star',
                StudyknowledgeNameType: '求Star',
                StudyknowledgeContent: '求Star',
                CreateDateTime: '2001-04-22',
                StudyknowledgeNameId: '',
                StudyTypeId: ''
            }/*,formLabelWidth:'120px'*/
            , rules: {
                StudyknowledgeName: [
                    { required: true, message: '请输入知识姓名', trigger: 'blur' },
                    { min: 2, max: 10, message: '名字不能太长或者太短', trigger: 'blur' }
                ], StudyknowledgeContent: [
                    { required: true, message: '请输入内容', trigger: 'change' },
                    { min: 2, max: 200, message: '内容不能太长或者太短', trigger: 'blur' }
                ], StudyknowledgeContent: [
                    { required: true, message: '请选择类型', trigger: 'change' }
                ]
            }
        }, mounted() {
            this.load();  //列表加载
            this.GetStudyType(); //下拉数据绑定 类型
        }, methods: {
            load() {
                //axios.post(url, this.form).then(result => { }).catch(error => { })
                axios.get("/Study/StudyknowledgeData").then(result => {
                    console.log(result)
                    this.tableData = result.data;
                }).catch(error => {
                    console.log(error)
                })
            }, GetStudyType()
            {
                axios.get("/Study/StudyTypeData").then(result => {
                    console.log(result)
                    this.StudyType = result.data;
                }).catch(error => {
                    console.log(error)
                })
            }
        }
        
    }
);