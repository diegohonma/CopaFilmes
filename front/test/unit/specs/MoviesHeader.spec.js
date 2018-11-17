import MoviesHeader from '../../../src/theme/MoviesHeader.vue'
import { shallowMount } from '@vue/test-utils'

describe('MoviesHeader.vue', () => {
  it('should render correct step', () => {
    const wrapper = shallowMount(MoviesHeader, {
      slots: {
        step: '<div name="step-test"></div>'
      }
    })
    expect(wrapper.find('div[name="step-test"]').exists()).to.equal(true)
  })

  it('should render correct step-desc', () => {
    const wrapper = shallowMount(MoviesHeader, {
      slots: {
        'step-desc': '<div name="step-desc-test"></div>'
      }
    })
    expect(wrapper.find('div[name="step-desc-test"]').exists()).to.equal(true)
  })
})
