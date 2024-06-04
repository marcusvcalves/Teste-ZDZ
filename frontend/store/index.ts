import { defineStore } from "pinia";
import type { State } from '@/types/index';

export const useMainStore = defineStore("main", {
  state: (): State => ({
    products: [
      {
        id: 1,
        name: "Lorem Ipsum",
        price: 1000,
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean a orci eleifend,tempus purus nec, varius nibh. Mauris risus justo, molestie et placerat ac, lobortis et ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean laoreet elit nec rhoncus imperdiet. Vestibulum sit amet augue ut nisi dictum varius. Etiam non libero in quam tristique dignissim et id arcu. Suspendisse dignissim porttitor rutrum. Nam venenatis arcu ante, id feugiat sem blandit ac. Nulla vitae diam metus."
      },
      {
        id: 2,
        name: "Lorem Ipsum",
        price: 500,
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean a orci eleifend,tempus purus nec, varius nibh. Mauris risus justo, molestie et placerat ac, lobortis et ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean laoreet elit nec rhoncus imperdiet. Vestibulum sit amet augue ut nisi dictum varius. Etiam non libero in quam tristique dignissim et id arcu. Suspendisse dignissim porttitor rutrum. Nam venenatis arcu ante, id feugiat sem blandit ac. Nulla vitae diam metus."
      },
      {
        id: 3,
        name: "Lorem Ipsum",
        price: 100,
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean a orci eleifend,tempus purus nec, varius nibh. Mauris risus justo, molestie et placerat ac, lobortis et ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean laoreet elit nec rhoncus imperdiet. Vestibulum sit amet augue ut nisi dictum varius. Etiam non libero in quam tristique dignissim et id arcu. Suspendisse dignissim porttitor rutrum. Nam venenatis arcu ante, id feugiat sem blandit ac. Nulla vitae diam metus."
      },
      {
        id: 4,
        name: "Lorem Ipsum",
        price: 100,
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean a orci eleifend,tempus purus nec, varius nibh. Mauris risus justo, molestie et placerat ac, lobortis et ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean laoreet elit nec rhoncus imperdiet. Vestibulum sit amet augue ut nisi dictum varius. Etiam non libero in quam tristique dignissim et id arcu. Suspendisse dignissim porttitor rutrum. Nam venenatis arcu ante, id feugiat sem blandit ac. Nulla vitae diam metus."
      },
      {
        id: 5,
        name: "Lorem Ipsum",
        price: 100,
        description: "Lorem ipsum."
      },
    ],
    categories: [
      {
        id: 1,
        name: "Electronics"
      },
      {
        id: 2,
        name: "Clothings"
      },
      {
        id: 3,
        name: "Sport"
      },
    ],
  })
})