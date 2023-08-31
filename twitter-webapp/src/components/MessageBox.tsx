import React, { SetStateAction, useEffect, useState } from "react";
import { api, message } from "../config/data";
import Messages, { IMsg } from "./Messages";
import axios from "axios";

interface IMBox {
  senderId: number | null;
  receiverId: number;
  setOpenMsg: any;
  receiverName: string | undefined;
}
const MessageBox = ({
  senderId,
  receiverId,
  setOpenMsg,
  receiverName,
}: IMBox) => {
  const [msg, setMsg] = useState("");
  const [recMsg, setRecMsg] = useState([]);
  const handleKeyDown = async (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key == "Enter") {
      if (msg == "") {
        return;
      }
      const data = {
        senderId,
        receiverId,
        message: msg,
      };
      try {
        const res = await axios.post(`${api}/Message`, data);
        console.log(res.data);
      } catch (err) {
        console.log(err);
      }
    }
  };

  useEffect(() => {
    const getMessages = async () => {
      try {
        const res = await axios.get(`${api}/Message/${senderId}`);
        setRecMsg(res.data);

        console.log(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getMessages();
  }, []);

  return (
    <div className=" h-[55vh] w-60 p-3 pb-5 border border-black bg-white">
      <div className="h-[10%] flex justify-between">
        <h1 className="font-bold text-lg">{receiverName?.toUpperCase()}</h1>
        <p
          className="text-black-500 font-extrabold cursor-pointer"
          onClick={() => setOpenMsg(false)}
        >
          X
        </p>
      </div>
      <hr className="mt-2 border border-black" />
      <div className="h-[80%] flex flex-col-reverse gap-1 overflow-y-scroll no-scrollbar">
        {recMsg.map((data: any) => (
          <Messages
            msg={data.message}
            senderId={data.senderId}
            receiverId={data.receiverId}
          />
        ))}
      </div>
      <div>
        <input
          className="w-[100%] p-1"
          placeholder="Write something"
          value={msg}
          onChange={(e) => setMsg(e.target.value)}
          onKeyDown={handleKeyDown}
        />
      </div>
    </div>
  );
};

export default MessageBox;
