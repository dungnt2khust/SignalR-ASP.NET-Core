export default {
    methods: {
        /**
         * Tuỳ chỉnh style
         * @param {Object} attributes
         * @returns Object
         * CreatedBy: NTDUNG (22/11/2021)
         */
        customizeStyle(attributes) {
           var customizeStyleObject = {};
           for(var att in attributes) {
               if (attributes[att]) { 
                   customizeStyleObject[att] = attributes[att] + "!important";
               }
           }
           return customizeStyleObject;
        },
        scrollElement() {
            console.log("Scroll");
        }
    }
}