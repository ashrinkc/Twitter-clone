import React, { useEffect, useState } from "react";
import InsertCommentIcon from "@mui/icons-material/InsertComment";
import ReplayIcon from "@mui/icons-material/Replay";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { api, commentsData } from "../config/data";
import Comments from "../components/Comments";
import { useLocation, useParams } from "react-router-dom";
import axios from "axios";
const IndividualPosts = () => {
  type IuserIP = {
    comments: number;
    createdDate: string;
    description: string;
    id: number;
    likes: number;
    quotes: number;
    user: {
      email: string;
      id: number;
      username: string;
    };
  };
  const [input, setInput] = useState("");
  const [empty, isEmpty] = useState(true);
  const [post, setPost] = useState<IuserIP>();
  const pIn = useLocation().state;
  const { id } = useParams();

  useEffect(() => {
    const getIndividualPost = async () => {
      try {
        const res = await axios.get(`${api}/Post/${id}`);
        console.log(res.data);
        setPost(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getIndividualPost();
  }, [id]);

  useEffect(() => {
    if (input.length > 0) {
      isEmpty(false);
    } else {
      isEmpty(true);
    }
  }, [input, setInput]);
  return (
    <div className="p-4">
      <div>
        <div className="flex gap-3">
          <div className="w-[8%]">
            <img
              className=" rounded-full h-10"
              src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
            />
          </div>
          <div className="w-[100%]">
            <h5 className="font-semibold">
              {pIn?.username}
              <a className="text-gray-500 font-medium ml-2">{pIn?.name}</a>
            </h5>
            <p>{pIn?.desc}</p>
            {/* <img
              className=" rounded-xl mt-4 max-h-[60vh]"
              src="https://ichef.bbci.co.uk/images/ic/640x360/p0fqd2bp.jpg"
            /> */}
            <div className="flex justify-around mt-2 ">
              <p>
                <InsertCommentIcon /> {pIn?.comments}
              </p>
              <p>
                <ReplayIcon /> {pIn?.quotes}
              </p>
              <p>
                <FavoriteBorderIcon
                  className={`${pIn?.isLike && "text-red-500"}`}
                />{" "}
                {pIn?.likes}
              </p>
            </div>
          </div>
        </div>
      </div>
      <hr className="mt-3" />
      <div className="flex gap-2 mt-3">
        <img
          className=" rounded-full h-10"
          src="https://pbs.twimg.com/profile_images/1598934317958574080/j5N41uYm_400x400.jpg"
        />
        <input
          placeholder="Post your reply!"
          className="w-[100%] p-1 focus:outline-none text-xl"
          value={input}
          onChange={(e) => setInput(e.target.value)}
        />
        <button
          className={`${
            empty ? "bg-blue-300" : "bg-blue-500"
          } text-white px-5 rounded-3xl`}
        >
          Reply
        </button>
      </div>
      <div className="mt-4">
        {commentsData.map((data) => (
          <Comments
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

export default IndividualPosts;
