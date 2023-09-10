import CakeIcon from "@mui/icons-material/Cake";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import Posts from "../components/Posts";
import { api, profilePost } from "../config/data";
import { Box, Modal } from "@mui/material";
import { useEffect, useState } from "react";
import EditProfile from "../components/EditProfile";
import { Link, useLocation } from "react-router-dom";
import { RootState } from "../redux/store";
import { useSelector } from "react-redux";
import axios from "axios";
import MessageBox from "../components/MessageBox";
import MessageIcon from "@mui/icons-material/Message";

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
  interface Iuser {
    email: string;
    username: string;
  }
  const [open, setOpen] = useState(false);
  const [hasFollowed, setHasFollowed] = useState();
  const [posts, setPosts] = useState([]);
  const [userS, setUserS] = useState<Iuser>();
  const [foll, setFoll] = useState();
  const [flo, setFlo] = useState();
  const [refresh, setRefresh] = useState<boolean>(false);
  const [uRef, setUref] = useState(false);
  const [openMsg, setOpenMsg] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const selectedId = useLocation().state;

  var isUser = true;
  if (selectedId != null) {
    isUser = user.id === selectedId;
  }

  useEffect(() => {
    const getUserData = async () => {
      try {
        const res = await axios.get(`${api}/User/${selectedId}`);
        setUserS(res.data);
      } catch (err) {
        console.log(err);
      }
    };

    getUserData();
    const getUserFollowCount = async () => {
      try {
        var id = user.id;
        if (selectedId != null) {
          id = selectedId;
        }
        const flo = await axios.get(`${api}/followCount/${id}`);
        const foll = await axios.get(`${api}/followingCount/${id}`);
        setFlo(flo.data);
        setFoll(foll.data);
      } catch (err) {
        console.log(err);
      }
    };
    getUserFollowCount();
  }, [selectedId, uRef]);

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

    const getUserPosts = async () => {
      try {
        var id = user.id;
        if (selectedId != null) {
          id = selectedId;
        }
        const res = await axios.get(`${api}/userPostsQuotes/${id}`);
        console.log(res.data);
        // const rr = await axios.get(`${api}/userQuotes/${id}`);
        // console.log(rr);
        setPosts(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getUserPosts();
    getRes();
  }, [uRef]);

  const handleFollow = async () => {
    const data = {
      userId: user?.id,
      followId: selectedId,
    };
    try {
      const res = await axios.post(`${api}/followUnfollow`, data);
      console.log(res);
      setUref(!uRef);
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
        <h1 className=" font-bold text-xl">
          {selectedId ? userS?.username : user.username}
        </h1>
        <p className="text-gray-500 flex">
          {selectedId ? userS?.email : user.email}
          {selectedId && (
            <p className="ml-1" onClick={() => setOpenMsg(true)}>
              <MessageIcon />
            </p>
          )}
        </p>
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
          {flo}
          <a className="text-gray-500">Followers</a>
        </p>
        <p className="font-semibold">
          {foll} <a className="text-gray-500">Following</a>
        </p>
      </div>
      <div className="mt-2">
        {posts.length > 0 ? (
          <>
            {posts.map((data: any) => (
              <Posts
                profileImg={data?.profileImg}
                desc={data.description}
                postImg={data.image}
                name={data.creatorEmail}
                username={data.creatorName}
                id={data.id}
                isLike={data.isLike}
                comments={data.comments}
                likes={data.likes}
                quotes={data.quotes}
                creatorId={data.creatorId}
                setRefresh={setRefresh}
                refresh={refresh}
                // retweeted={data[0]?.isQuote}
              />
            ))}
          </>
        ) : (
          <div className="flex justify-center items-center mt-4 text-xl">
            <h1>No Posts</h1>
          </div>
        )}
        {openMsg && (
          <div className=" absolute right-20 bottom-10 z-10">
            <MessageBox
              receiverId={selectedId}
              senderId={user.id}
              setOpenMsg={setOpenMsg}
              receiverName={userS?.username}
            />
          </div>
        )}
      </div>
    </div>
  );
};

export default Profile;
