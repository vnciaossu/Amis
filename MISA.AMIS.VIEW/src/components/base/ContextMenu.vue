<template>
    <div class="context-menu"
         v-show="show"
         :style="style"
         ref="context"
         tabindex="0"
         @blur="close">
        <slot></slot>
    </div>
</template>

<script>
    import Vue from "vue";
    export default {
        name: "CmpContextMenu",
        props: {
            display: Boolean,
        },
        data() {
            return {
                left: 0, // left position
                top: 0, // top position
                show: false, // affect display of context menu
            };
        },
        computed: {
            // get position of context menu
            style() {
                return {
                    top: this.top + "px",
                    left: this.left + "px",
                };
            },
        },
        methods: {
            // closes context menu
            close() {
                this.show = false;
                this.left = 0;
                this.top = 0;
            },
            open(evt) {
                // updates position of context menu
                this.left = evt.pageX - 125 || evt.clientX - 125;
                this.top = evt.pageY + 15 || evt.clientY + 15;
                
                Vue.nextTick(() => this.$el.focus());
                this.show = true;
            },
        },
    };
</script>

<style>
    .context-menu {
        position: fixed;
        background: white;
        z-index: 999;
        outline: none;
        /* box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24); */
        border: 1px solid #babec5;
        cursor: pointer;
    }
</style>
