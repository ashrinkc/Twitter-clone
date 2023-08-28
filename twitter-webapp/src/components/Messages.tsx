import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";

export interface IMsg {
  senderId: number;
  receiverId: number;
  msg: string;
}

const Messages = ({ senderId, receiverId, msg }: IMsg) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);

  return <div className={`${senderId === user.id && "text-right"}`}>{msg}</div>;
};

export default Messages;
