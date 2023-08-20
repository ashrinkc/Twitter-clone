import CakeIcon from "@mui/icons-material/Cake";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import Posts from "../components/Posts";
import { api, profilePost } from "../config/data";
import { Box, Modal } from "@mui/material";
import { useEffect, useState } from "react";
import EditProfile from "../components/EditProfile";
import { useLocation } from "react-router-dom";
import { RootState } from "../redux/store";
import { useSelector } from "react-redux";
import axios from "axios";

const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  maxWidth: 600,
  bgcolor: "background.paper",
  borderRadius: "1vw",
  //   border: "2px solid #000",
  //   boxShadow: 24,
  p: 1,
};
const Profile = () => {
  const [open, setOpen] = useState(false);
  const [hasFollowed, setHasFollowed] = useState();
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const selectedId = useLocation().state;
  var isUser = true;
  if (selectedId != null) {
    isUser = user.id === selectedId;
  }
  useEffect(() => {
    const data = {
      userId: user?.id,
      followId: selectedId,
    };
    const getRes = async () => {
      try {
        const res = await axios.post(`${api}/isFollowed`, data);
        setHasFollowed(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getRes();
  }, []);
  const handleFollow = async () => {
    const data = {
      userId: user?.id,
      followId: selectedId,
    };
    try {
      const res = await axios.post(`${api}/followUnfollow`, data);
      console.log(res);
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div className=" h-screen">
      <div className="relative h-[40%]">
        <img
          className="w-full h-52"
          src="https://pbs.twimg.com/profile_banners/1064149828693880837/1542548435/1500x500"
        />
        <img
          className=" rounded-full h-28 absolute top-36 left-3"
          src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
        />
        <div className="absolute right-7 mt-2">
          {isUser ? (
            <button
              className="rounded-3xl border border-black p-1 w-28"
              onClick={handleOpen}
            >
              Edit profile
            </button>
          ) : (
            <button
              className="rounded-3xl border border-black p-1 w-28"
              onClick={handleFollow}
            >
              {hasFollowed ? "Unfollow" : "Follow"}
            </button>
          )}
        </div>
        <Modal
          open={open}
          onClose={handleClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box sx={style}>
            <EditProfile setOpen={setOpen} />
          </Box>
        </Modal>
      </div>
      <div className="mt-2">
        <h1 className=" font-bold text-xl">Ashrin K.C</h1>
        <p className="text-gray-500">@ashrin_c</p>
        <div className="flex gap-5 text-gray-500 font-mono items-center mt-2">
          {/* <p className="flex items-center justify-center gap-2">
            <CakeIcon />
            Born November 16, 1995
          </p> */}
          <p className="flex items-center justify-center gap-2">
            <CalendarMonthIcon />
            Joined November 2018
          </p>
        </div>
      </div>
      <div className="flex gap-3 mt-2">
        <p className="font-semibold">
          91 <a className="text-gray-500">Followers</a>
        </p>
        <p className="font-semibold">
          60 <a className="text-gray-500">Following</a>
        </p>
      </div>
      <div className="mt-2">
        {profilePost.map((data) => (
          <Posts
            profileImg={data.profileImg}
            desc={data.desc}
            postImg={data.postImg}
            name={data.name}
            username={data.username}
          />
        ))}
      </div>
    </div>
  );
};

export default Profile;
