require("@rushstack/eslint-patch/modern-module-resolution")

module.exports = {
  extends: [
    'eslint:recommended',
    'plugin:vue/vue3-strongly-recommended',
    '@vue/eslint-config-typescript',
  ]
}