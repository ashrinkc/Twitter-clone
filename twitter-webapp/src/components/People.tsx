import React from "react";
import { Link } from "react-router-dom";

export interface IUserE {
  id: number;
  username: string;
  email: string;
  image?: string;
  joinDate?: string;
}
const People = ({ id, username, email, image, joinDate }: IUserE) => {
  return (
    <>
      <div className="flex justify-between items-center pr-2 pl-2 w-[100%]">
        <div className="flex gap-2 items-center w-[80%]">
          <div>
            <img
              className=" rounded-full h-9"
              src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
            />
          </div>
          <h2 className=" font-semibold text-sm">{username}</h2>
        </div>
        <div>
          <Link to={`/profile`} state={id}>
            <button className="bg-blue-500 text-white w-[5vw] rounded-2xl p-1">
              View
            </button>
          </Link>
        </div>
      </div>
      <hr className="w-[100%] bg-black" />
    </>
  );
};

export default People;
