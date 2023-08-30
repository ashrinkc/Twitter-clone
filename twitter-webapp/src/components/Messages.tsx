import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";

export interface IMsg {
  senderId: number | null;
  receiverId: number;
  msg?: string;
}

const Messages = ({ senderId, receiverId, msg }: IMsg) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);

  return (
    <div
      className={`${
        senderId === user.id && "text-right text-blue-500"
      } font-bold`}
    >
      {msg}
    </div>
  );
};

export default Messages;
