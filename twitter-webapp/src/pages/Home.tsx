import { RefObject, useEffect, useRef, useState } from "react";
import InputTweet from "../components/InputTweet";
import Posts from "../components/Posts";
import { api, forYouPost, postData } from "../config/data";
import axios from "axios";
import { RootState } from "../redux/store";
import { useSelector } from "react-redux";

const Home = () => {
  const [select, setIsSelect] = useState("FYP");
  const inputRef: RefObject<HTMLInputElement> = useRef<HTMLInputElement>(null);
  const user = useSelector((state: RootState) => state.auth.currentUser);
  useEffect(() => {
    const getFypPosts = async () => {
      try {
        const res = await axios.get(`${api}/post?userId=${user.id}`);
        console.log(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    getFypPosts();
  }, []);
  return (
    <div>
      <h1 className="font-bold text-lg">Home</h1>
      <div className="flex w-[100%]">
        <div className="w-[50%] p-3 flex justify-center">
          <h3
            className={`font-semibold ${
              select === "FYP" ? `text-black` : "text-gray-500"
            } cursor-pointer`}
            onClick={() => setIsSelect("FYP")}
          >
            For you
          </h3>
        </div>
        <div className="w-[50%] p-3 flex justify-center">
          <h3
            className={`font-semibold ${
              select === "Following" ? `text-black` : "text-gray-500"
            } cursor-pointer`}
            onClick={() => setIsSelect("Following")}
          >
            Following
          </h3>
        </div>
      </div>
      <div className="w-[100%] p-3">
        <InputTweet Iref={inputRef} />
      </div>
      <div className="mt-10">
        {select === "Following" ? (
          <>
            {" "}
            {postData.map((data) => (
              <Posts
                profileImg={data.profileImg}
                desc={data.desc}
                postImg={data.postImg}
                name={data.name}
                username={data.username}
                retweeted={data.retweet}
              />
            ))}{" "}
          </>
        ) : (
          <>
            {" "}
            {forYouPost.map((data) => (
              <Posts
                profileImg={data.profileImg}
                desc={data.desc}
                postImg={data.postImg}
                name={data.name}
                username={data.username}
              />
            ))}
          </>
        )}
      </div>
    </div>
  );
};

export default Home;
