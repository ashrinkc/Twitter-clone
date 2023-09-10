import React, { useEffect, useState } from "react";
import { api, history } from "../config/data";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../redux/store";
import axios from "axios";
import { changeRefresh } from "../redux/historySlice";

const History = () => {
  const [historyy, setHistory] = useState([]);
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const dispatch = useDispatch<AppDispatch>();
  const val = useSelector((state: RootState) => state.history.refresh);
  useEffect(() => {
    const getHistory = async () => {
      try {
        const res = await axios.get(`${api}/History/${user.id}`);
        setHistory(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getHistory();
  }, [val]);

  const deleteHistory = async (id: number) => {
    const res = await axios.delete(`${api}/History/${id}`);
    console.log(res.data);
    await dispatch(changeRefresh());
  };

  return (
    <div className="p-2 flex flex-col gap-3 bg-gray-100 h-72 rounded-xl">
      <h1 className="font-bold text-xl">History</h1>
      {historyy.map((data: any) => (
        <div className="flex justify-between">
          <p className="font-serif">{data.search}</p>
          <p
            className="text-red-500 font-extrabold cursor-pointer"
            onClick={() => deleteHistory(data.id)}
          >
            X
          </p>
        </div>
      ))}
    </div>
  );
};

export default History;
