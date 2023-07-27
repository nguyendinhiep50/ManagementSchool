import React,{useEffect,useState} from 'react';
import { Table,Popconfirm, Typography  } from 'antd';
import type { ColumnsType } from 'antd/es/table';
import axios from 'axios';
interface DataType {
  id: React.Key;
  imageTeacher:boolean;
  nameTeacher: string;
  phoneTeacher: number;
  emailTeacher: string;
  birthDateTeacher: string;
  adressTeacher: string;

}

const columns: ColumnsType<DataType> = [
  { title: 'imageTeacher', dataIndex: 'imageTeacher', key: 'imageTeacher' },
  { title: 'nameTeacher', dataIndex: 'nameTeacher', key: 'nameTeacher' },
  { title: 'phoneTeacher', dataIndex: 'phoneTeacher', key: 'phoneTeacher' },
  { title: 'emailTeacher', dataIndex: 'emailTeacher', key: 'emailTeacher' },
  { title: 'birthDateTeacher', dataIndex: 'birthDateTeacher', key: 'birthDateTeacher' },

  { title: 'adressTeacher', dataIndex: 'adressTeacher', key: 'adressTeacher' },
  {
    title: 'Action',
    dataIndex: '',
    key: 'x',
    render: (_: any, record: data) => {
        return record.Register ? (
          <Typography.Link  onClick={() => {record.Register= false }}>
            <a>Hủy ký học</a>
          </Typography.Link>
        ) : (
          <Typography.Link  onClick={() => {record.Register= true}}>
            <a>Đăng ký học</a>
          </Typography.Link>
        );
      },
  },
];

const App: React.FC = () => {
    const [data, setdata] = useState([]);
    useEffect(() => {
    axios
      .get("https://localhost:7232/api/Teachers")
      .then((response) => {
        const data1 = response.data;
        setdata(data1);
        console.log('thanh cong');
        console.log(data);
        // Do something with the data, such as updating state
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);
  return (
  <Table
    columns={columns} 
    dataSource={data}
  />
)};

export default App;