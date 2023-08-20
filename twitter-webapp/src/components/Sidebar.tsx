import { sidebar } from "../config/data";
import HomeIcon from "@mui/icons-material/Home";
import TravelExploreIcon from "@mui/icons-material/TravelExplore";
import PersonIcon from "@mui/icons-material/Person";
import LogoutIcon from "@mui/icons-material/Logout";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Box, Modal } from "@mui/material";
import TweetModal from "./TweetModal";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../redux/store";
import { clearCurrentUser } from "../redux/authSlice";
const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  // maxWidth: 600,

  bgcolor: "background.paper",
  borderRadius: "1vw",
  //   border: "2px solid #000",
  //   boxShadow: 24,
  p: 2,
};
const Sidebar = () => {
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const [selected, isSelected] = useState("Home");

  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  // const user = useSelector((state: RootState) => state.auth.currentUser);
  const handleClick = async (type: string) => {
    isSelected(type);
    if (type === "Home") {
      navigate("/");
    } else if (type === "Explore") {
      navigate("/explore");
    } else if (type === "Profile") {
      navigate("/profile");
    } else if (type === "Logout") {
      await dispatch(clearCurrentUser());
      navigate("/login");
    }
  };
  return (
    <div className="h-screen flex flex-col gap-10">
      <div className=" flex flex-col gap-7 cursor-pointer">
        {sidebar.map((data) => (
          <div
            className={`flex gap-2  items-center ${
              selected === data.type ? "text-black" : "text-gray-500"
            }  p-2 rounded-3xl hover:bg-gray-100`}
            onClick={() => handleClick(data.type)}
            key={Math.random()}
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
      <button
        onClick={handleOpen}
        className="bg-blue-500 rounded-2xl p-3 w-[100%] text-white"
      >
        Tweet
      </button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <TweetModal setOpen={setOpen} />
        </Box>
      </Modal>
    </div>
  );
};

export default Sidebar;
