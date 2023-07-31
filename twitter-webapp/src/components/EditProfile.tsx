import { TextField } from "@mui/material";
import { useState } from "react";
import CloseIcon from "@mui/icons-material/Close";

type IOpen = {
  setOpen: (value: boolean) => void;
};
const EditProfile = ({ setOpen }: IOpen) => {
  const [name, setName] = useState("Ashrin K.C");
  return (
    <div>
      <div className="flex justify-between items-center">
        <div className="flex gap-5 items-center">
          <h1 className="font-mono text-xl" onClick={() => setOpen(false)}>
            <CloseIcon />
          </h1>
          <h1 className="font-semibold text-xl">Edit Profile</h1>
        </div>
        <div>
          <button className="text-white bg-black p-1 w-20 rounded-2xl text-sm">
            Save
          </button>
        </div>
      </div>
      <div className="relative h-[40%] pb-14 pt-2">
        <img
          className="w-full h-52"
          src="https://pbs.twimg.com/profile_banners/1064149828693880837/1542548435/1500x500"
        />
        <img
          className=" rounded-full h-28 absolute top-36 left-3"
          src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
        />
      </div>
      <div>
        <TextField
          id="outlined-basic"
          sx={{ width: "100%" }}
          label="Name"
          variant="outlined"
          //   placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </div>
    </div>
  );
};

export default EditProfile;
