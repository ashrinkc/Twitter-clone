import { sidebar } from "../config/data";
import HomeIcon from "@mui/icons-material/Home";
import TravelExploreIcon from "@mui/icons-material/TravelExplore";
import PersonIcon from "@mui/icons-material/Person";
import LogoutIcon from "@mui/icons-material/Logout";
import { useState } from "react";
const Sidebar = () => {
  const [selected, isSelected] = useState("Home");
  return (
    <div className="h-screen flex flex-col gap-10">
      <div className=" flex flex-col gap-7 cursor-pointer">
        {sidebar.map((data) => (
          <div
            className={`flex gap-2  items-center ${
              selected === data.type ? "text-black" : "text-gray-500"
            }  p-2 rounded-3xl hover:bg-gray-100`}
            onClick={() => isSelected(data.type)}
          >
            {data.type === "Home" ? (
              <HomeIcon />
            ) : data.type === "Explore" ? (
              <TravelExploreIcon />
            ) : data.type === "Logout" ? (
              <LogoutIcon />
            ) : (
              <PersonIcon />
            )}
            <h1 className=" text-xl">{data.type}</h1>
          </div>
        ))}
      </div>
      <button className="bg-blue-500 rounded-2xl p-3 w-[100%] text-white">
        Tweet
      </button>
    </div>
  );
};

export default Sidebar;
