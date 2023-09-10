import { createSlice } from "@reduxjs/toolkit";

export const historySlice = createSlice({
  name: "history",
  initialState: {
    refresh: false,
  },
  reducers: {
    changeRefresh: (state) => {
      state.refresh = !state.refresh;
    },
  },
});

export const { changeRefresh } = historySlice.actions;
export default historySlice.reducer;
